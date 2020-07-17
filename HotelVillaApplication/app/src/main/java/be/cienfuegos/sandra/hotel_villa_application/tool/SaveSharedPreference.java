package be.cienfuegos.sandra.hotel_villa_application.tool;

import android.content.Context;
import android.content.SharedPreferences;

import static android.content.SharedPreferences.Editor;

public class SaveSharedPreference {

    private static final String PREFERENCE_NAME = "VILLA_APPLICATION_PREFERENCE";
    private static final String USER_PREFERENCE_NAME = "USER_PREFERENCE";

    public static SharedPreferences getPreferences(Context context) {
        return context.getSharedPreferences(PREFERENCE_NAME, Context.MODE_PRIVATE);
    }

    public static void setUser(Context context, boolean loggedIn) {
        Editor editor = getPreferences(context).edit();
        editor.putBoolean(USER_PREFERENCE_NAME, loggedIn);
        editor.apply();
    }

    public static boolean getUser(Context context) {
        return getPreferences(context).getBoolean(USER_PREFERENCE_NAME, false);
    }
}
