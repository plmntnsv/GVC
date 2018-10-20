$(function () {
    // ON CLICK ODD
    $(".event-preview-odd").on("click", function () {
        var $this = $(this);
        var oddType = $this.closest("table").find("th").eq($this.index() - 1)[0].innerText;
        var oddValue = $this[0].innerText;
        var oddEventId = $this.closest("tr").find(".preview-event-id").val();
        console.log(oddEventId + " " + oddType + " " + oddValue);
    });
});