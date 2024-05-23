const uri = "/Login";
const loginFrom = document.getElementById('login-from');




function Login2(){
    const nameTextbox =loginFrom.name.value;
    const passwordTextbox = loginFrom.password.value;
    Login(nameTextbox,passwordTextbox)

}
const Login = async (nameTextbox,passwordTextbox) => {
    await fetch(uri, {
        method: 'POST',
        body: JSON.stringify(
            {
            "Name": nameTextbox,
                "Password": passwordTextbox
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
        })}
        

        function handleCredentialResponse(response) {
            if (response.credential) {
                var idToken = response.credential;
                var decodedToken = parseJwt(idToken);
                var userName = decodedToken.name;
                var userPassword = decodedToken.sub;
                Login(userName, userPassword);
            } else {
                alert('Google Sign-In was cancelled.');
            }
        }
        
        
        //Parses JWT token from Google Sign-In
        function parseJwt(token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));
        
            return JSON.parse(jsonPayload);
        }
    // await GetIdByNameAndPassword(loginFrom.name.value, loginFrom.password.value);


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