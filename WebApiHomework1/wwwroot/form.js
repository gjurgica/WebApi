let firstName = document.getElementById("firstName");
let lastName = document.getElementById("lastName");
let age = document.getElementById("age");
let submit = document.getElementById("submit");
let id = 4;


let port = "57593";
let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/user";

    let response = await fetch(url);
    let data = await response.json();
    console.log(data);
};

let addUser = async () => {
    let url = "http://localhost:" + port + "/api/user";
   
    let user = { Id: id++,FirstName:firstName.value,LastName:lastName.value,Age:age.value }
    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
}
getAllUsers();
submit.addEventListener("click", addUser);