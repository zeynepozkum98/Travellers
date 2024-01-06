const loginForm = document.getElementById('login-form');

loginForm.addEventListener('submit', function (e) {
    e.preventDefault();

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Perform authentication here (e.g., check the credentials against a database)
    // For a basic example, you can hardcode the credentials and check them.
    if (username === 'yourUsername' && password === 'yourPassword') {
        alert('Login successful! Redirecting to your account...');
        // You can redirect the user to their account page or any other page.
    } else {
        alert('Login failed. Please check your credentials.');
    }
});