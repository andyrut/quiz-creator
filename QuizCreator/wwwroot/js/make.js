var doInit = false;

var quillOpts = {
    content: "html",
    contentType: "html",
    placeholder: "Enter a question..."
};
VueQuill.QuillEditor.props.globalOptions.default = () => quillOpts;

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
}).component("QuillEditor", VueQuill.QuillEditor).mount("#app");

var templateGuid = $("#templateGuid").val();
$.get("/api/makefetch/" + templateGuid,
    function (response) {
        app.template = response;
        console.log("makefetch success");
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