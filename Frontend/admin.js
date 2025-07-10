window.onload = async function () {
  try {
    const response = await fetch('https://localhost:7021/api/Interns');
    if (!response.ok) throw new Error('Failed to fetch data');
    
    const interns = await response.json();
    const tableBody = document.querySelector('#applicationsTable tbody');

    interns.forEach(intern => {
      const row = document.createElement('tr');

      row.innerHTML = `
        <td>${intern.id}</td>
        <td>${intern.name}</td>
        <td>${intern.email}</td>
        <td>${intern.education}</td>
        <td>${intern.phone}</td>
        <td>${intern.gender}</td>
        <td>${intern.duration}</td>
        <td><a href="https://localhost:7021/resumes/${intern.resumeFileName}" target="_blank">View Resume</a></td>
      `;

      tableBody.appendChild(row);
    });

  } catch (err) {
    alert('Error loading applications: ' + err.message);
  }
};
