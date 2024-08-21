


function onPost(url,data,successCalb) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: successCalb ? function (response) {
            if (response.success) {
                console.log(response)
            } else {
                $("div.text-danger").text("");
                $.each(response.errors, function (key, messages) {
                    var field = $("[name='" + key + "']");
                    field.next(".text-danger").text(messages[0]);
                });
            }
        } :
            successCalb
    });
}