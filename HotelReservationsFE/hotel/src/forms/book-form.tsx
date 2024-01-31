import { useState } from 'react';
import './book-form.css';
import { bookReservation } from '../endpoints/endpoints';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
    faCircleXmark,
} from "@fortawesome/free-solid-svg-icons";

export default function BookForm() {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [email, setEmail] = useState('');
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());

    const submit = () =>
    {
        bookReservation(name, surname, email, startDate, endDate);
    }

    return (
        <form className="popup" >
            <div className="container popup-inner" align-center>
            <button className="closeButton">
            <FontAwesomeIcon icon={faCircleXmark}/>
            </button>
            <div className="content">
                    <div className="form2">
                    <form action="" >
                            <div className="txt">Name</div>
                            <input
                                type="text"
                                name={`firstname`}
                                required
                                className="form-control"
                                placeholder=""
                                onChange={(e) => setName(e.target.value)}
                            />
                            <div className="txt">Last Name</div>
                            <input
                                type="text"
                                name={`lastname`}
                                required
                                className="form-control"
                                placeholder=""
                                onChange={(e) => setSurname(e.target.value)}
                            />
                            <div className="txt">E-mail</div>
                            <input
                                type="email"
                                name={`email`}
                                required
                                className="form-control"
                                placeholder=""
                                onChange={(e) => setEmail(e.target.value)}
                            />
                        <div className="txt">Date you would like to Stay</div>
                            <div className="inputData">
                                <input type="date" name="" id="book-date" onChange={(e) => setStartDate(new Date(e.target.value))} />
                                
                            </div>
                            <div className="txt">Date you would like to leave</div>
                            <div className="inputData">
                                <input type="date" name="" id="leave-date" onChange={(e) => setEndDate(new Date(e.target.value))}/>
                            </div>
                            <div className="book">
                                <button type="submit" onClick={submit}>Book</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </form>
    );
}