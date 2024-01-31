
export const getHotels = () => {
    fetch('https://localhost:58921/hotel/all')
       .then(response => response.json())
       .then(data => console.log(data));
}

export const bookReservation = (name: string, surname:string, email:string, startDate: Date, endDate:Date) => {
    fetch('https://localhost:58921/visitor/create', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({Name:name, Surname: surname, Email: email})
    })
    .then(response => response.json())
    .then(data => {
            return fetch('https://localhost:58921/reservation/create', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({HotelId: "1", VistorId: String(data.Id), StartDate: String(startDate), EndDate: String(endDate)})
        })
        }
    )
    .then(response => response.json())
    .then(response => console.log(response))
   
}