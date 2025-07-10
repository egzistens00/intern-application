document.getElementById('loginForm').addEventListener('submit', function (e) {
  e.preventDefault();

  const username = document.getElementById('username').value.trim();
  const password = document.getElementById('password').value.trim();

  // Hardcoded credentials for demo
  if (username === 'admin' && password === 'admin123') {
    window.location.href = 'admin.html';
  } else {
    document.getElementById('errorMsg').innerText = 'Invalid credentials. Try again.';
  }
});
