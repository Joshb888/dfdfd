﻿//https://github.com/sonnd9x/Bitly.Net/blob/master/Bitly.Net/BitlyAPI.cs

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Resgrid.Model.Providers;

namespace Resgrid.Providers.Marketing
{
	public class ShortenUrlProvider: IShortenUrlProvider
	{
		public string ACCESS_TOKEN { get; set; }

		/// <summary>
		/// Create new Bitly object with access token
		/// </summary>
		/// <param name="access_token"></param>
		public ShortenUrlProvider()
		{
			ACCESS_TOKEN = Config.LinksConfig.BitlyAccessToken;
		}

		/// <summary>
		/// Check Access Token using synchronous method
		/// </summary>
		/// <returns></returns>
		public async Task<bool> CheckAccessToken()
		{
			if (string.IsNullOrEmpty(ACCESS_TOKEN))
				return false;

			string temp = string.Format(Config.LinksConfig.BitlyApi, ACCESS_TOKEN, "google.com");
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage res = await client.GetAsync(temp);
				return res.IsSuccessStatusCode;
			}
		}

		/// <summary>
		/// Check Access Token using asynchronous
		/// </summary>
		/// <returns></returns>
		public async Task<bool> CheckAccessTokenAsync()
		{
			return await CheckAccessToken();
		}

		/// <summary>
		/// Shortern long URL using synchronous
		/// </summary>
		/// <param name="long_url"></param>
		/// <returns></returns>
		public async Task<string> Shorten(string long_url)
		{
			if (Config.SystemBehaviorConfig.LinkProviderType == Config.LinksProviderTypes.Bitly)
			{
				if (await CheckAccessToken())
				{
					using (HttpClient client = new HttpClient())
					{
						string temp = string.Format(Config.LinksConfig.BitlyApi, ACCESS_TOKEN, WebUtility.UrlEncode(long_url));
						var res = await client.GetAsync(temp);
						if (res.IsSuccessStatusCode)
						{
							var message = await res.Content.ReadAsStringAsync();
							dynamic obj = JsonConvert.DeserializeObject(message);
							return obj.results[long_url].shortUrl;
						}
						else
						{
							return "Can not short URL";
						}
					}
				}
				else
				{
					return "Can not short URL";
				}
			}
			else if (Config.SystemBehaviorConfig.LinkProviderType == Config.LinksProviderTypes.Polr)
			{
				using (HttpClient client = new HttpClient())
				{
					string temp = string.Format(Config.LinksConfig.PolrApi, Config.LinksConfig.PolrAccessToken, WebUtility.UrlEncode(long_url));
					var res = await client.GetAsync(temp);
					if (res.IsSuccessStatusCode)
					{
						var message = await res.Content.ReadAsStringAsync();
						return message.Trim();
					}
					else
					{
						return "Can not short URL";
					}
				}
			}

			return "Can not short URL";
		}

		/// <summary>
		/// Shortern long URL using asynchronous
		/// </summary>
		/// <param name="long_url"></param>
		/// <returns></returns>
		public async Task<string> ShortenAsync(string long_url)
		{
			return await Shorten(long_url);
		}
	}
}
