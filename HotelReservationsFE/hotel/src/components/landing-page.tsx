import './landing-page.css'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
    faCircleArrowLeft,
    faCircleArrowRight,
    faCircleXmark,
    faLocationDot,
} from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";
import BookForm from "../forms/book-form";
import { bookReservation } from '../endpoints/endpoints';

export const LandingPage = () => {
    const [slideNumber, setSlideNumber] = useState(0);
    const [open, setOpen] = useState(false);
    const [openForm, setFormOpen] = useState(false);

    const openFormOnClick = () => {
        setFormOpen(true)
    }

    // bookReservation();

    const photos = [
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-facade-6235-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-lobby-0746-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-lobby-7102-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-deluxe-6242-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-king-guestroom-7268-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
        {
            src: "https://cache.marriott.com/content/dam/marriott-renditions/ROMWI/romwi-deluxe-0739-hor-clsc.jpg?output-quality=70&interpolation=progressive-bilinear&downsize=1215px:*",
        },
    ];

    const handleOpen = (i: number) => {
        setSlideNumber(i);
        setOpen(true);
    };

    const handleMove = (direction: string) => {
        let newSlideNumber;

        if (direction === "l") {
            newSlideNumber = slideNumber === 0 ? 5 : slideNumber - 1;
        } else {
            newSlideNumber = slideNumber === 5 ? 0 : slideNumber + 1;
        }

        setSlideNumber(newSlideNumber)
    };
    

    return (
        <div>
            <div className="hotelContainer">
                {open && (
                    <div className="slider">
                        <FontAwesomeIcon
                            icon={faCircleXmark}
                            className="close"
                            onClick={() => setOpen(false)}
                        />
                        <FontAwesomeIcon
                            icon={faCircleArrowLeft}
                            className="arrow"
                            onClick={() => handleMove("l")}
                        />
                        <div className="sliderWrapper">
                            <img src={photos[slideNumber].src} alt="" className="sliderImg" />
                        </div>
                        <FontAwesomeIcon
                            icon={faCircleArrowRight}
                            className="arrow"
                            onClick={() => handleMove("r")}
                        />
                    </div>
                )}
                <div className="hotelWrapper">
                    <button className="bookNow" onClick={openFormOnClick}>Book Now!</button>
                    <h1 className="hotelTitle">The Westin Excelsior, Rome</h1>
                    <div className="hotelAddress">
                        <FontAwesomeIcon icon={faLocationDot} />
                        <span>Via Vittorio Veneto, 125, 00187 Roma RM</span>
                    </div>
                    <span className="hotelDistance">
                        Excellent location!
                    </span>
                    <span className="hotelPriceHighlight">
                        Book a stay over $499 at this property and get a free airport ride
                    </span>
                    <div className="hotelImages">
                        {photos.map((photo, i) => (
                            <div className="hotelImgWrapper" key={i}>
                                <img
                                    onClick={() => handleOpen(i)}
                                    src={photo.src}
                                    alt=""
                                    className="hotelImg"
                                />
                            </div>
                        ))}
                    </div>
                    <div className="hotelDetails">
                        <div className="hotelDetailsTexts">
                            <h1 className="hotelTitle">About our hotel</h1>
                            <p className="hotelDesc">
                                Our luxury hotel is one of the city&apos;s most iconic palaces, rich in history and located on the legendary Via Veneto. The Westin Excelsior is nestled between the Spanish Steps and the Borghese Gardens & Gallery.
                                Our family friendly hotel features 281 rooms and 35 unique Signature Suites, including one of the most spectacular and opulent suites in Europe the Villa La Cupola. The Villa offers the ultra-elite a truly Roman Emperor experience.
                            </p>
                        </div>
                        <div className="hotelDetailsPrice">
                            <h1>Get a great deal for a 7 night stay!</h1>
                            <span>
                                Located in the real heart of Rome, this property has an
                                excellent location score of 9.5!
                            </span>
                            <h2>
                                <b>$1499</b> (7 nights)
                            </h2>
                        </div>
                    </div>
                </div>
                {openForm &&
                    <BookForm></BookForm>
                }
            </div>
        </div>
    );
};