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
   