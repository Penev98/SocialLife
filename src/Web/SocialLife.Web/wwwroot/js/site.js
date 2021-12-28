document.querySelector('#submitPost').addEventListener('click',() => {

    if (document.querySelector('#postContent').value == '') {
        alert('You cannot create an empty post.')
    }
    
})

let btns = Array.from(document.querySelectorAll('#editPostButton'));

btns.forEach(x =>x.addEventListener('click', (event) => {
    let postBody = event.currentTarget.parentNode.parentNode.parentNode.parentNode.parentNode;
    let postContent = postBody.querySelector('p#content').textContent;
    let postId = event.currentTarget.querySelector('#hiddenId').textContent;
    document.querySelector('#modalArea').textContent = postContent;
    document.querySelector('#postId').value = postId;
    
}));

let btnIsClicked = false;

$(document).on('click', '#likeButton', function changeLike(event) {

    let postId = "hello"; // Get the clicked post from the event target

        if (btnIsClicked != true) {
            document.querySelector('#likeButton').style.fill = 'red';
            btnIsClicked = true;

            //To-Do: increment likes count in the browser
            likePost(postId);
            
        } else {
            document.querySelector('#likeButton').style.fill = 'none';
            btnIsClicked = false;

            //To-Do: Decrement likes count in the browser
            dislikePost(postId);
        }  
});

function likePost(postId){
    $.ajax({
        type: "GET",
        url: "/Posts/LikePost",
        data: { postId: postId},
        dataType: "json",
        success: function (result) {
            if (result) {
                console.log("User liked post.");
            }
            else {
                console.log("Unsuccessful attempt at liking a post.")
            }
        }
    });
}

function dislikePost(postId) {
    $.ajax({
        type: "GET",
        url: "/Posts/DislikePost",
        data: { postId: postId},
        dataType: "json",
        success: function (result) {
            if (result) {
                console.log("User disliked post.");
            }
            else {
                console.log("Unsuccessful attempt at disliking a post.")
            }
        }
    });
}