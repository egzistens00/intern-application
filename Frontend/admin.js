window.onload = async function () {
  try {
    const response = await fetch('https://intern-api-alif.azurewebsites.net/api/interns');
    if (!response.ok) throw new Error('Failed to fetch data');
    
    const interns = await response.json();
    const tableBody = document.querySelector('#applicationsTable tbody');

    if (interns.length === 0) {
      const row = document.createElement('tr');
      row.innerHTML = `<td colspan="8" class="text-center text-muted">No applications found.</td>`;
      tableBody.appendChild(row);
      return;
    }

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
        <td>N/A</td> <!-- Add resume link here if available -->
      `;

      tableBody.appendChild(row);
    });

  } catch (err) {
    alert('Error loading applications: ' + err.message);
    console.error(err);
  }
};
