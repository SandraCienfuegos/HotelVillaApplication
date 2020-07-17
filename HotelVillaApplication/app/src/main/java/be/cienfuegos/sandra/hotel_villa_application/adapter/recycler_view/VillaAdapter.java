package be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.synnapps.carouselview.CarouselView;
import com.synnapps.carouselview.ImageListener;

import org.jetbrains.annotations.NotNull;

import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.R;
import be.cienfuegos.sandra.hotel_villa_application.VillaDetailsActivity;
import be.cienfuegos.sandra.hotel_villa_application.VillaDetailsActivity_;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Villa;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaMedia;

public class VillaAdapter extends RecyclerView.Adapter<VillaAdapter.VillaViewHolder> {
    private final List<Villa> villas;
    private final int idLinearLayout;


    public VillaAdapter(List<Villa> villas, int idLinearLayout) {
        this.villas = villas;
        this.idLinearLayout = idLinearLayout;
    }

    @NotNull
    @Override
    public VillaAdapter.VillaViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View linearLayout = LayoutInflater.from(parent.getContext()).inflate(idLinearLayout, parent, false);
        return new VillaViewHolder(linearLayout);
    }

    @Override
    public void onBindViewHolder(VillaViewHolder holder, int position) {
        holder.onBind(villas.get(position));
    }

    @Override
    public int getItemCount() {
        return villas.size();
    }

    static class VillaViewHolder extends RecyclerView.ViewHolder {
        private View linearLayout;
        private CarouselView villaMediaCarouselView;
        private TextView nameTextView;

        VillaViewHolder(final View linearLayout) {
            super(linearLayout);
            this.linearLayout = linearLayout;
            villaMediaCarouselView = linearLayout.findViewById(R.id.villa_media_carousel_view);
            nameTextView = linearLayout.findViewById(R.id.name_text_view);

            int width = villaMediaCarouselView.getLayoutParams().width;
            int height = linearLayout.getResources().getDisplayMetrics().heightPixels / 3;
            villaMediaCarouselView.setLayoutParams(new LinearLayout.LayoutParams(width, height));
        }

        void onBind(final Villa villa) {
            nameTextView.setText(villa.getVillaName());
            final List<VillaMedia> villaMedias = villa.getMedias();
            villaMediaCarouselView.setImageListener((position, imageView) -> Glide
                    .with(linearLayout.getContext())
                    .load(HotelVillaApiClient.getInstance().getVillaMediaUrl(villaMedias.get(position)))
                    .into(imageView));
            villaMediaCarouselView.setPageCount(villa.getMedias().size());
            linearLayout.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    VillaDetailsActivity_.intent(linearLayout.getContext())
                            .villa(villa)
                            .start();

                }
            });
        }
    }
}