$(document).ready(function () {
    $('.open-feedback-form').magnificPopup({
        type: 'inline',
        midClick: true
    });

    $("#feedbackForm").submit(function (e) {
        e.preventDefault();  // Prevent default form submission

        $.ajax({
            type: "POST",
            url: "/Home/AddFeedback",  // Adjust URL if needed
            data: $("#feedbackForm").serialize(),
            success: function (response) {
                alert("Feedback submitted successfully!");
                window.location.href = "/Home/Index";  // Redirect to home page
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
                alert("An error occurred. Please try again.");
            }
        });
    });
});