document.querySelector('#submitPost').addEventListener('click',() => {

    if (document.querySelector('#postContent').value == '') {
        alert('You cannot create an empty post.')
    }
    
})