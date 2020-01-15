namespace BE
{
    /* the prupose of this code file is to combine all of the enums */

    /// <summary>
    /// necessary, possible, notInterested
    /// </summary>
    public enum Request { necessary, possible, notInterested };

    /// <summary>
    ///All,North,South,Center,Jerusalem
    /// </summary>
    public enum Location { All, North, South, Center, Jerusalem };

    /// <summary>
    ///  NotAddressed,SentEmail,ClosedForCustomerUnresponsiveness,ClosedForCustomerResponse
    /// </summary>
    public enum StatusOrder
    {
        NotAddressed/*טרם טופל*/, SentEmail/* נשלח מייל*/,
        ClosedForCustomerUnresponsiveness/*נסגר מחוסר הענות של הלקוח*/,
        ClosedForCustomerResponse/*נסגר בהיענות של הלקוח*/
    };

    /// <summary>
    /// Open, DealWasClosedThroughTheSite, ClosedBecauseItExpired
    /// </summary>
    public enum GuestRequestStatus
    {
        Open, DealWasClosedThroughTheSite/*נסגרה עסקה דרך האתר*/,
        ClosedBecauseItExpired/*נסגרה כי פג תוקפה*/
    };

    /// <summary>
    /// GuesRoom, Apartment, HotelRoom, Tent
    /// </summary>
    public enum KindOfUnit { GuesRoom, Apartment, HotelRoom, Tent, hut};
}

