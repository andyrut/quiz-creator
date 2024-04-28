var app = Vue.createApp({
    data() {
        return {
            template: {
                name: "",
                description: "",
                questions: []
            }
        }
    }
}).mount("#app");

var templateGuid = $("#templateGuid").val();
$.get("/api/makefetch/" + templateGuid,
    function(response) {
        app.template = response;
    });


function update() {
    $.ajax({
        url: "/api/makeupdate",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(app.template),
        success: function() {
            alert("hunky dory");
        }
    });
}