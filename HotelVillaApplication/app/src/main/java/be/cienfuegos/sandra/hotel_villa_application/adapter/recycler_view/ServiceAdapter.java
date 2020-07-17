package be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import java.util.List;
import java.util.stream.Collectors;

import be.cienfuegos.sandra.hotel_villa_application.R;
import be.cienfuegos.sandra.hotel_villa_application.api.model.ReservationService;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Service;

public class ServiceAdapter extends RecyclerView.Adapter<ServiceAdapter.ServiceViewHolder> {
    private final List<Service> services;
    private final int idLinearLayout;


    public ServiceAdapter(List<Service> services, int idLinearLayout) {
        this.services = services;
        this.idLinearLayout = idLinearLayout;
    }

    @NotNull
    @Override
    public ServiceViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View linearLayout = LayoutInflater.from(parent.getContext()).inflate(idLinearLayout, parent, false);
        return new ServiceViewHolder(linearLayout);
    }

    @Override
    public void onBindViewHolder(ServiceViewHolder holder, int position) {
        holder.onBind(services.get(position));
    }

    @Override
    public int getItemCount() {
        return services.size();
    }

    public List<Service> getSelectedServices() {
        return services
                .stream()
                .filter((x) -> x.isSelected)
                .collect(Collectors.toList());
    }

    public List<ReservationService> getSelectedReservationServices() {
        return getSelectedServices()
                .stream()
                .map(service -> new ReservationService(service.getServiceId()))
                .collect(Collectors.toList());
    }

    static class ServiceViewHolder extends RecyclerView.ViewHolder implements CompoundButton.OnCheckedChangeListener {
        private Service service;
        private View linearLayout;
        private TextView serviceNameTextView;
        private TextView servicePriceTextView;
        private CheckBox selectedCheckBox;

        ServiceViewHolder(final View linearLayout) {
            super(linearLayout);
            this.linearLayout = linearLayout;
            serviceNameTextView = linearLayout.findViewById(R.id.service_name_text_view);
            servicePriceTextView = linearLayout.findViewById(R.id.service_price_text_view);
            selectedCheckBox = linearLayout.findViewById(R.id.selected_check_box);
            selectedCheckBox.setOnCheckedChangeListener(this);
        }

        void onBind(final Service service) {
            this.service = service;
            serviceNameTextView.setText(service.getServiceName());
            servicePriceTextView.setText(String.format("%.2f€", service.getServicePrice()));
            selectedCheckBox.setChecked(service.isSelected);
        }

        @Override
        public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
            service.isSelected = b;
        }
    }
}