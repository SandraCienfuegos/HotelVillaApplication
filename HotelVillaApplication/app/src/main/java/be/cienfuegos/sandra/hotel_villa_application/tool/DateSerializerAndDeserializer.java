package be.cienfuegos.sandra.hotel_villa_application.tool;

import android.annotation.SuppressLint;
import android.util.Log;

import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonParseException;
import com.google.gson.JsonPrimitive;
import com.google.gson.JsonSerializationContext;
import com.google.gson.JsonSerializer;

import java.lang.reflect.Type;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

/**
 * Code issu d'internet qui sérialise et déserialise une date
 */
@SuppressLint("SimpleDateFormat")
public class DateSerializerAndDeserializer implements JsonSerializer<Date>, JsonDeserializer<Date> {

    private static final SimpleDateFormat FORMAT = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

    static {
        FORMAT.setTimeZone(TimeZone.getTimeZone("GMT"));
    }

    @Override
    public JsonElement serialize(Date date, Type typeOfSrc, JsonSerializationContext context) {
        return new JsonPrimitive(FORMAT.format(date));
    }

    @Override
    public Date deserialize(JsonElement element, Type type, JsonDeserializationContext context) throws JsonParseException {
        String date = element.getAsString();

        try {
            return FORMAT.parse(date);
        } catch (ParseException exp) {
            exp.printStackTrace();
            return null;
        }
    }
}
