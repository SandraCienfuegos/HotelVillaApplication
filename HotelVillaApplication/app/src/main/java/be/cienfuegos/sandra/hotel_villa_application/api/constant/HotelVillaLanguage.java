package be.cienfuegos.sandra.hotel_villa_application.api.constant;

import org.jetbrains.annotations.NotNull;

import java.util.Locale;

public enum HotelVillaLanguage {
    ARABIC("Arabic", "ar"),
    ENGLISH("English", "en"),
    FRENCH("French", "fr"),
    SPANISH("Spanish", "es");

    private String languageName;
    private String isoCode;

    HotelVillaLanguage(String languageName, String isoCode) {
        this.languageName = languageName;
        this.isoCode = isoCode;
    }

    public String getIsoCode() {
        return isoCode;
    }

    public String getLanguageName() {
        return languageName;
    }

    @NotNull
    @Override
    public String toString() {
        return languageName;
    }

    public static HotelVillaLanguage detect(Locale locale) {
        String languageCode = locale.toLanguageTag().substring(0, 2);
        for (HotelVillaLanguage hotelVillaLanguage : HotelVillaLanguage.values()) {
            if (hotelVillaLanguage.isoCode.equals(languageCode)) {
                return hotelVillaLanguage;
            }
        }
        return HotelVillaLanguage.ENGLISH;
    }
}
