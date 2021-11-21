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


   
