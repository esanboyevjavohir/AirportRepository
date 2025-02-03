namespace Airways.Core.Common
{
    public record Errorr(string code, string message)
    {
        public static Errorr None = new Errorr(string.Empty, string.Empty);

        public static Errorr NullValue = new Errorr("Error.NullValue", "Null value was provided");
        public static Errorr DataBaseError = new Errorr("Error.DataBaseError", "There is some problem with the DataBase");
        public static Errorr BadRequest = new Errorr("Error.BadRequest", "Somewhere the query didn't work");
        public static Errorr NotFound = new Errorr("Error.NotFound", "NotFound");
        public static Errorr Unauthorized = new Errorr("Error.Unauthorized", "Unauthorized");
        public static Errorr Forbidden = new Errorr("Error.Forbidden", "Forbidden");
        public static Errorr Conflict = new Errorr("Error.Conflict", "Conflict");
        public static Errorr InternalServerError = new Errorr("Error.InternalServerError", "Internal Server Error");
        public static Errorr LoginFaild = new Errorr("Error.LoginFaild", "Username or Password is incorrect");
        public static Errorr TechnicalWorks = new Errorr("Error.TechnicalWorks", "Ushbu Apida texnik ishlar olib borilmoqda");
        public static Errorr DatabaseError = new Errorr("Error.DatabaseError", "Database error");
        public static Errorr InvalidOperation = new Errorr("Error.InvalidOperation", "Invalid operation");
        public static Errorr TimeSlotOverlap = new Errorr("Error.TimeSlotOverlap", "Time slot overlaps with existing appointment");
        public static Errorr ScheduleHasAppointments = new Errorr("Error.ScheduleHasAppointments", "Schedule has appointments");
        public static Errorr TimeSlotNotAvailable = new Errorr("Error.TimeSlotNotAvailable", "Time slot is not available");
    }
}
