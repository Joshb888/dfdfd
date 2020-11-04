
var resgrid;
(function (resgrid) {
    var profile;
    (function (profile) {
        var addscheduledreport;
        (function (addscheduledreport) {
            $(document).ready(function () {
                $('#SpecifcDateTime').kendoDateTimePicker({
                    interval: 15
                });
                $('#DayOfWeekTime').kendoTimePicker({
                    interval: 15
                });
                var selectedValue = $('#SpecificDatetime').val();
                if (selectedValue === 'True') {
                    $("#specificdatetimearea").show();
                    $("#daysoftheweekarea").hide();
                    $("#daysoftheweekarea_time").hide();
                }
                else if (selectedValue === 'False') {
                    $("#specificdatetimearea").hide();
                    $("#daysoftheweekarea").show();
                    $("#daysoftheweekarea_time").show();
                }
                else {
                    $("#specificdatetimearea").hide();
                    $("#daysoftheweekarea").hide();
                    $("#daysoftheweekarea_time").hide();
                }
                $("#SpecificDatetime").change(function (e) {
                    switch ($(this).val()) {
                    case "True":
                        $("#specificdatetimearea").show();
                        $("#daysoftheweekarea").hide();
                        $("#daysoftheweekarea_time").hide();
                        break;
                    case "False":
                        $("#specificdatetimearea").hide();
                        $("#daysoftheweekarea").show();
                        $("#daysoftheweekarea_time").show();
                        break;    
                    }
                });
            });
        })(addscheduledreport = profile.addscheduledreport || (profile.addscheduledreport = {}));
    })(profile = resgrid.profile || (resgrid.profile = {}));
})(resgrid || (resgrid = {}));
