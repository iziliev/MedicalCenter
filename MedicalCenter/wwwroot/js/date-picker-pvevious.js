$(document).ready(function() {

    $('.datepicker').datepicker({
        format: 'dd.mm.yyyy',
        autoclose: true,
        startDate: '01.01.1996'
    });

    $('.cell').click(function() {
        $('.cell').removeClass('select');
        $(this).addClass('select');
        $("#selectedTime").text(this.innerHTML);
        $("#Hour").val(this.innerHTML);
    });

    $("#dp1").on('change',
        function() {
            $("#selectedDate").text(this.value);
            $("#Date").val(this.value);
        });
});