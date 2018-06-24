
$(document).ready(



    function () {

        $('#tet').click(function () {
            $.ajax({
                type: "GET",
                url: "/Schedule/test1",
                success: function (data) {
                    $('#myModal').find('.modal-content').append(data);

                    console.log($('#exampleModal1').find('.modal-content').append(data));

                    $('#myModal').show();
                }
            })

        });



    }
);
