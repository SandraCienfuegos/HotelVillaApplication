package be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import org.jetbrains.annotations.NotNull;

import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.R;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Equipment;

public class VillaEquipmentAdapter extends RecyclerView.Adapter<VillaEquipmentAdapter.VillaEquipmentViewHolder> {
    private final List<Equipment> equipments;
    private final int idLinearLayout;


    public VillaEquipmentAdapter(List<Equipment> equipments, int idLinearLayout) {
        this.equipments = equipments;
        this.idLinearLayout = idLinearLayout;
    }

    @NotNull
    @Override
    public VillaEquipmentViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View linearLayout = LayoutInflater.from(parent.getContext()).inflate(idLinearLayout, parent, false);
        return new VillaEquipmentViewHolder(linearLayout);
    }

    @Override
    public void onBindViewHolder(VillaEquipmentViewHolder holder, int position) {
        holder.onBind(equipments.get(position));
    }

    @Override
    public int getItemCount() {
        return equipments.size();
    }

    static class VillaEquipmentViewHolder extends RecyclerView.ViewHolder {
        private View linearLayout;
        private ImageView equipmentIconImageView;
        private TextView equipmentNameTextView;

        VillaEquipmentViewHolder(final View linearLayout) {
            super(linearLayout);
            this.linearLayout = linearLayout;
            equipmentIconImageView = linearLayout.findViewById(R.id.equipment_icon_image_view);
            equipmentNameTextView = linearLayout.findViewById(R.id.equipment_name_text_view);
        }

        void onBind(final Equipment equipment) {
            Glide
                    .with(linearLayout.getContext())
                    .load(HotelVillaApiClient.getInstance().getEquipmentMediaUrl(equipment))
                    .into(equipmentIconImageView);

            equipmentNameTextView.setText(equipment.getEquipmentName());
        }
    }
}