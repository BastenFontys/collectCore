const ctx = document.getElementById('myChart').getContext('2d');
new Chart(ctx, {
    type: 'line',
data: {
    labels: ['January', 'February', 'March', 'April', 'May', 'June'],
datasets: [{
    label: 'Collection Growth',
data: [10, 20, 15, 30, 40, 35],
borderColor: 'rgba(181, 178, 0, 1)',
backgroundColor: 'rgba(235, 233, 70, 0.2)',
borderWidth: 2,
fill: true
            }]
        },
options: {
    responsive: true,
maintainAspectRatio: false,
scales: {
    y: {
    beginAtZero: true
                }
            }
        }
    });
