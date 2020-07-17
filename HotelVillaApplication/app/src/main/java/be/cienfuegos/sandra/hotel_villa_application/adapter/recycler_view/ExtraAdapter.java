package be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view;

import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import java.util.List;
import java.util.stream.Collectors;

import be.cienfuegos.sandra.hotel_villa_application.R;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Extra;
import be.cienfuegos.sandra.hotel_villa_application.api.model.ReservationExtra;

public class ExtraAdapter extends RecyclerView.Adapter<ExtraAdapter.ExtraViewHolder> {
    private final List<Extra> extras;
    private final int idLinearLayout;


    public ExtraAdapter(List<Extra> extras, int idLinearLayout) {
        this.extras = extras;
        this.idLinearLayout = idLinearLayout;
    }

    @NotNull
    @Override
    public ExtraViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View linearLayout = LayoutInflater.from(parent.getContext()).inflate(idLinearLayout, parent, false);
        return new ExtraViewHolder(linearLayout);
    }

    @Override
    public void onBindViewHolder(ExtraViewHolder holder, int position) {
        holder.onBind(extras.get(position));
    }

    @Override
    public int getItemCount() {
        return extras.size();
    }

    public List<Extra> getSelectedExtras() {
        return extras
                .stream()
                .filter((x) -> x.isSelected)
                .collect(Collectors.toList());
    }

    public List<ReservationExtra> getSelectedReservationExtras() {
        return getSelectedExtras()
                .stream()
                .map(extra -> new ReservationExtra(extra.getExtraId(), extra.number))
                .collect(Collectors.toList());
    }

    static class ExtraViewHolder extends RecyclerView.ViewHolder implements CompoundButton.OnCheckedChangeListener, View.OnKeyListener {
        private Extra extra;
        private View linearLayout;
        private TextView extraNameTextView;
        private TextView extraPriceTextView;
        private EditText numberEditText;
        private CheckBox selectedCheckBox;

        ExtraViewHolder(final View linearLayout) {
            super(linearLayout);
            this.linearLayout = linearLayout;
            extraNameTextView = linearLayout.findViewById(R.id.extra_name_text_view);
            extraPriceTextView = linearLayout.findViewById(R.id.extra_price_text_view);
            numberEditText = linearLayout.findViewById(R.id.number_edit_text);
            numberEditText.setOnKeyListener(this);
            selectedCheckBox = linearLayout.findViewById(R.id.selected_check_box);
            selectedCheckBox.setOnCheckedChangeListener(this);
        }

        void onBind(final Extra extra) {
            this.extra = extra;
            extraNameTextView.setText(extra.getExtraName());
            extraPriceTextView.setText(String.format("%.2f€", extra.getExtraPrice()));
            numberEditText.setText(String.valueOf(extra.number));
            selectedCheckBox.setChecked(extra.isSelected);
        }

        @Override
        public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
            extra.isSelected = b;
        }

        @Override
        public boolean onKey(View view, int i, KeyEvent keyEvent) {
            String rawNumber = numberEditText.getText().toString();
            extra.number = rawNumber.length() != 0 ? Integer.parseInt(rawNumber) : 0;
            return false;
        }
    }
}