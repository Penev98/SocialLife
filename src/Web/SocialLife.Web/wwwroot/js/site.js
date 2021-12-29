
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

let likeButtons = [...document.querySelectorAll('#likeButton')];
likeButtons.forEach(x => x.addEventListener('click', (event) => {
    let targetButton = event.currentTarget;
    let postId = targetButton.attributes.itemid.value;

    let buttonRef = targetButton.parentNode;

    if (targetButton.attributes.fill.value == 'none') {
        targetButton.attributes.fill.value = 'red';

        likePost(postId, buttonRef);
    } else {
        targetButton.attributes.fill.value = 'none';

        dislikePost(postId, buttonRef);
    }
}));


function likePost(postId,button) {
        $.ajax({
            type: "GET",
            url: "/Posts/LikePost",
            data: { postId: postId },
            dataType: "json",
            success: function (result) {
                if (result) {
                    console.log("User liked post.");
                    updatePostLikesCount(postId, button)
                }
                else {
                    console.log("Unsuccessful attempt at liking a post.")
                }               
            }
        });
}

function dislikePost(postId, button) {
        $.ajax({
            type: "GET",
            url: "/Posts/DislikePost",
            data: { postId: postId },
            dataType: "json",
            success: function (result) {
                if (result) {
                    console.log("User disliked post.");
                    updatePostLikesCount(postId,button);
                }
                else {
                    console.log("Unsuccessful attempt at disliking a post.")
                }
            }
        });
}

function updatePostLikesCount(postId,button) {
    $.ajax({
        type: "GET",
        url: "/Posts/GetPostLikesCount",
        data: { postId: postId },
        dataType: "json",
        success: function (result) {
            if (result != -1) {
                button.querySelector('#postLikesCount').textContent = `Like(${result})`;
            }
            else {
                console.log("Unsuccessful attempt at updating post likes count.")
            }
        }
    });
}