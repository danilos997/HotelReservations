
export const getHotels = () => {
    fetch('https://localhost:58921/hotel/all')
       .then(response => response.json())
       .then(data => console.log(data));
}

export const bookReservation = (name: string, surname:string, email:string, startDate: Date, endDate:Date) : boolean => {
    var result = false; 
    fetch('https://localhost:58921/visitor/create', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({Name:name, Surname: surname, Email: email})
    })
    .then(response => response.json())
    .then(visitor => {
        console.log(visitor.id)
            return fetch('https://localhost:58921/reservation/create', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({HotelId: "1", VisitorId: String(visitor.id), StartDate: startDate.toJSON(), EndDate: endDate.toJSON()})
        })
    })
    .then(response => response.json())
    .then(response => {
        if(response.id != null){
            console.log(response, "reservation");
            result = true;
        }
    })

    return result;
}