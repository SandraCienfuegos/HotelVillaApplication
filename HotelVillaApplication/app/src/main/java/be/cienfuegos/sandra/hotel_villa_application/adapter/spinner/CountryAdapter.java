package be.cienfuegos.sandra.hotel_villa_application.adapter.spinner;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.LayoutRes;

import org.jetbrains.annotations.NotNull;

import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.api.model.Country;

public class CountryAdapter extends ArrayAdapter<Country> {

    private final LayoutInflater layoutInflater;
    private final List<Country> countries;
    private final int resource;

    public CountryAdapter(Context context, @LayoutRes int resource, List<Country> countries) {
        super(context, resource, 0, countries);
        layoutInflater = LayoutInflater.from(context);
        this.resource = resource;
        this.countries = countries;
    }

    @Override
    public View getDropDownView(int position, View convertView, @NotNull ViewGroup parent) {
        return createItemView(position, parent);
    }

    @NotNull
    @Override
    public View getView(int position, View convertView, @NotNull ViewGroup parent) {
        return createItemView(position, parent);
    }

    @SuppressLint("DefaultLocale")
    private View createItemView(int position, ViewGroup parent) {
        View countryTextViewView = layoutInflater.inflate(resource, parent, false);

        ((TextView) countryTextViewView).setText(countries.get(position).getCountryName());

        return countryTextViewView;
    }
}