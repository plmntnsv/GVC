$(function () {
    var $ulErrors = $(".validation-summary-valid ul");
    var token = $('input[name="__RequestVerificationToken"]').val();
    
    //SAVE EVENT
    $("#edit-events-table").on("click", ".event-save", function () {
        var $this = $(this);
        $ulErrors.children().remove();

        var $id = $this.attr("data-id");
        var $selectedEventRow = $(`.event-row-${$id}`);
        var $name = $selectedEventRow.find(".event-name-input").val();
        var $oddsForFirstTeam = $selectedEventRow.find(".event-oddsforfirstteam-input").val();
        var $oddsForDraw = $selectedEventRow.find(".event-oddsfordraw-input").val();
        var $oddsForSecondTeam = $selectedEventRow.find(".event-oddsforsecondteam-input").val();
        var $startDate = $selectedEventRow.find(".event-startdate-input").val();
        
        $.ajax({
            type: "POST",
            url: "/Event/Save/",
            dataType: "json",
            data: {
                __RequestVerificationToken: token,
                Id: $id,
                Name: $name,
                OddsForFirstTeam: $oddsForFirstTeam,
                OddsForDraw: $oddsForDraw,
                OddsForSecondTeam: $oddsForSecondTeam,
                StartDate: $startDate
            },
            success: function (jsonResult) {
                if (jsonResult.success) {
                    $ulErrors.append(`<li class="text-success">${jsonResult.responseText}</li>`);
                }
                else {
                    jsonResult.data.forEach(e => $ulErrors.append(`<li class="text-danger">${e}</li>`));
                }
            },
            error: function (res) {
                $(".body-content").html(res.responseText);
            }
        });
    });

    //DELETE EVENT
    $("#edit-events-table").on("click", ".event-delete", function () {
        var $this = $(this);

        $ulErrors.children().remove();

        var $id = $this.attr("data-id");
        var $selectedEventRow = $(`.event-row-${$id}`);
        
        $.ajax({
            type: "POST",
            url: "/Event/Delete/",
            dataType: "json",
            data: {
                __RequestVerificationToken: token,
                id: $id
            },
            success: function (jsonResult) {
                if (jsonResult.success) {
                    $ulErrors.append(`<li class="text-success">${jsonResult.responseText}</li>`);
                }
                else {
                    jsonResult.data.forEach(e => $ulErrors.append(`<li class="text-danger">${e}</li>`));
                }

                $selectedEventRow.remove();
            },
            error: function (res) {
                $(".body-content").html(res.responseText);
            }
        });
    });

    // ADD EVENT
    $("#event-add").on("click", function () {
        var $eventTable = $("#edit-events-table");

        $.ajax({
            type: "GET",
            url: "/Event/Add/",
            dataType: "html",
            success: function (res) {
                $eventTable.append(res);
            },
            error: function (res) {
                $(".body-content").html(res.responseText);
            }
        });
    });
});