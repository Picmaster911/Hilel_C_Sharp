<script>
    var curentURL = window.location.protocol + "//" + window.location.host
    const inputName = document.querySelector(`#inputName`)
    const inputValue = document.querySelector(`#inputValue`)
    const priorityNote = document.querySelector(`#priorityNote`)
    let myNoteForEdite = {
        Id: @Model.Id,
        Name: inputName.defaultValue,
        Value: inputValue.defaultValue,
        Priority: @Model.Priority
        }
    const uri = `${curentURL}/Home/EditeSelectedNote`;

    inputName.addEventListener("input", updateName);
    priorityNote.addEventListener("input", updatePriotity);
    inputValue.addEventListener("input", updateValue);

    function updatePriotity(e) {

        myNoteForEdite.Priority = (e.target.value);
    }

    function updateValue(e) {

        myNoteForEdite.Value = (e.target.value);
    }

    function updateName(e) {
        myNoteForEdite.Name = (e.target.value);
    }
   
    console.log(myNoteForEdite);
    const ButtonOk = document.querySelector(`#ButtonOk`)
    ButtonOk.addEventListener("click", () => {
        PostController(myNoteForEdite);

    })
    function PostController(myNoteForEdite) {
      let respone =  fetch( uri, {       
            method: 'post',
            referrer: "",
            cache: "no-cache",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(myNoteForEdite)
        }).then((response) => {
            alert(`You change id = ${myNoteForEdite.Id} Name = ${myNoteForEdite.Name} Value = ${myNoteForEdite.Value} saved`);
            console.log("Post successfully created!")
            return response.json()           
        }).then((res) => {
            if (res.status === 201) {
                console.log("Post successfully created!")
            }
        }).catch((error) => {
            console.log(error)
        })
    }
</script>