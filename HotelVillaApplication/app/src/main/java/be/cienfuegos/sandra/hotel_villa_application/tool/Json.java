package be.cienfuegos.sandra.hotel_villa_application.tool;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.Reader;
import java.lang.reflect.Type;
import java.util.Date;

/**
 * Classe utilitaire qui permet la sérialisation et la déserialisation
 */
public class Json {
    /**
     * Instance de GSON, la bibliothèque de Google
     */
    private static final Gson GSON = new GsonBuilder()
            .registerTypeAdapter(Date.class, new DateSerializerAndDeserializer())
            .create();

    public static String serialize(Object object) {
        return GSON.toJson(object);
    }

    public static <T> T deserialize(Reader reader, Type type) {
        return GSON.fromJson(reader, type);
    }

}
