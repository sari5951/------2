const uri = "/Login";
const loginFrom = document.getElementById('login-from');


const Login = async () => {
    await fetch(uri, {
        method: 'POST',
        body: JSON.stringify(
            {
                "Name": loginFrom.name.value,
                "Password": loginFrom.password.value
            }
        ),
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(res => {
            if (!res.ok) {
                console.log("res: " + res.ok + res);
                throw new Error('Login-faild!')
            }
            else
                return res.text();
        })
        .then(token => {
            console.log("I accept token: " + token);
            localStorage.setItem('token', token);
            window.location.href = './index.html';
        })
        .catch(error => {
            console.error("Login faild: " + error)
            alert('login faild')
        })
    // await GetIdByNameAndPassword(loginFrom.name.value, loginFrom.password.value);
};

// loginFrom.onsubmit = async () => {
//     console.log(`loginFrom.Name: ${loginFrom.name.value} loginFrom.Name: ${loginFrom.password.value}`);
//     await Login();
// }

// const GetIdByNameAndPassword = async (Name, Password) => {
//     await fetch(`Login?Name=${Name}&Password=${Password}`, {
//         method: 'GET',
//         headers: {
//             'Content-Type': 'application/json',
//         },
//     })
//         .then(res => {
//             if (!res.ok) {
//                 console.log("res: " + res.ok + res);
//                 throw new Error('getIdByNameAndPassword-faild!')
//             }
//             else
//                 return res.text();
//         })
//         .then(id => {
//             console.log("I accept id: " + id);
//             localStorage.setItem("userId", id)
//             window.location.href = './index.html';
//         })
//         .catch(error => {
//             console.error("GetIdByNameAndPassword faild: " + error)
//             alert('GetIdByNameAndPassword faild')
//         })
// };


// function onSignIn(googleUser) {
//     var profile = googleUser.getBasicProfile();
//     console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
//     console.log('Name: ' + profile.getName());
//     console.log('Image URL: ' + profile.getImageUrl());
//     console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
//   }