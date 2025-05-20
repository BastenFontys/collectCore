const DATA = @Html.Raw(Json.Serialize(Model.Data));

const CONTEXT = document.getElementById('myChart').getContext('2d');
new Chart(CONTEXT,
{
    type: 'line', data:
    {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'Juli', 'August', 'September', 'Oktober', 'November', 'December'],
        datasets:
        [{
            label: 'Collection Growth',
            data: DATA,
            borderColor: 'rgba(181, 178, 0, 1)',
            backgroundColor: 'rgba(235, 233, 70, 0.2)',
            borderWidth: 2,
            fill: true
        }]
    },
    options:
    {
        responsive: true,
        maintainAspectRatio: false,
        scales:
        {
            y:
            {
                beginAtZero: true
            }
        }
    }
});
