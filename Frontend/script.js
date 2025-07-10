document.getElementById('internForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const formData = new FormData();
    formData.append('name', document.getElementById('name').value);
    formData.append('email', document.getElementById('email').value);
    formData.append('education', document.getElementById('education').value);
    formData.append('phone', document.getElementById('phone').value);
    const gender = document.querySelector('input[name="gender"]:checked');
    formData.append('gender', gender ? gender.value : '');
    formData.append('duration', document.getElementById('duration').value);
    formData.append('resume', document.getElementById('resume').files[0]);

    try {
        const response = await fetch('https://localhost:7021/api/Interns', {
            method: 'POST',
            body: formData,
        });

        if (response.ok) {
            alert('✅ Application submitted successfully!');
            document.getElementById('internForm').reset();
        } else {
            const errorText = await response.text();
            alert('❌ Error submitting application:\n' + errorText);
        }
    } catch (error) {
        alert('❌ Failed to submit application: ' + error.message);
    }
});
