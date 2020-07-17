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

import be.cienfuegos.sandra.hotel_villa_application.R;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Formula;

public class FormulaAdapter extends ArrayAdapter<Formula> {

    private final LayoutInflater layoutInflater;
    private final List<Formula> formulas;
    private final int resource;

    public FormulaAdapter(Context context, @LayoutRes int resource, List<Formula> formulas) {
        super(context, resource, 0, formulas);
        layoutInflater = LayoutInflater.from(context);
        this.resource = resource;
        this.formulas = formulas;
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
        View formulaTile = layoutInflater.inflate(resource, parent, false);
        TextView formulaNameTextView = formulaTile.findViewById(R.id.formula_name_text_view);
        TextView formulaAdultPriceTextView = formulaTile.findViewById(R.id.formula_adult_price_text_view);
        TextView formulaChildPriceTextView = formulaTile.findViewById(R.id.formula_child_price_text_view);
        TextView formulaBabyPriceTextView = formulaTile.findViewById(R.id.formula_baby_price_text_view);

        Formula formula = formulas.get(position);

        formulaNameTextView.setText(formula.getFormulaName());
        formulaAdultPriceTextView.setText(String.format("%.2f€", formula.getPriceAdult()));
        formulaChildPriceTextView.setText(String.format("%.2f€", formula.getPriceChild()));
        formulaBabyPriceTextView.setText(String.format("%.2f€", formula.getPriceBaby()));
        return formulaTile;
    }
}