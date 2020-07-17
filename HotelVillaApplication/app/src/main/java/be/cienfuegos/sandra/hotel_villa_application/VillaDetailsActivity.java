package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.synnapps.carouselview.CarouselView;

import org.androidannotations.annotations.AfterViews;
import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Extra;
import org.androidannotations.annotations.Fullscreen;
import org.androidannotations.annotations.ViewById;

import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view.VillaEquipmentAdapter;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Villa;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaMedia;

@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_villa_details)
public class VillaDetailsActivity extends Activity {

    @Extra
    Villa villa;

    @ViewById(R.id.villa_name_text_view)
    TextView villaNameEditText;

    @ViewById(R.id.villa_media_carousel_view)
    CarouselView villaMediaCarouselView;

    @ViewById(R.id.price_on_site_text_view)
    TextView priceOnSiteTextView;


    @ViewById(R.id.price_online_text_view)
    TextView priceOnlineTextView;

    @ViewById(R.id.villa_description_text_view)
    TextView villaDescriptionTextView;

    @ViewById(R.id.villa_number_of_beds_text_view)
    TextView villaNumberOfBedsTextView;

    @ViewById(R.id.villa_surface_area_text_view)
    TextView villaSurfaceAreaTextView;

    @ViewById(R.id.villa_equipments_recycler_view)
    RecyclerView villaEquipmentsRecyclerView;


    @SuppressLint("DefaultLocale")
    @AfterViews
    protected void initView() {
        villaNameEditText.setText(villa.getVillaName());

        int width = villaMediaCarouselView.getLayoutParams().width;
        int height = this.getResources().getDisplayMetrics().heightPixels / 3;

        villaMediaCarouselView.setLayoutParams(new LinearLayout.LayoutParams(width, height));

        final List<VillaMedia> villaMedias = villa.getMedias();

        villaMediaCarouselView.setImageListener((position, imageView) -> Glide
                .with(VillaDetailsActivity.this)
                .load(HotelVillaApiClient.getInstance().getVillaMediaUrl(villaMedias.get(position)))
                .into(imageView));
        villaMediaCarouselView.setPageCount(villa.getMedias().size());

        priceOnlineTextView.setText(String.format("%.2f€", villa.getPriceOnline()));
        priceOnSiteTextView.setText(String.format("%.2f€", villa.getPriceOnSite()));

        villaDescriptionTextView.setText(villa.getDescription());

        villaNumberOfBedsTextView.setText(String.format("%d %s", villa.getNumberOfBeds() * 2, getString(R.string.persons)));
        villaSurfaceAreaTextView.setText(String.format("%d%s", villa.getSurfaceArea(), getString(R.string.square_metre)));

        villaEquipmentsRecyclerView.setHasFixedSize(false);
        villaEquipmentsRecyclerView.setLayoutManager(new LinearLayoutManager(this));
        RecyclerView.Adapter adapter = new VillaEquipmentAdapter(villa.getEquipments(), R.layout.equipment_tile);
        villaEquipmentsRecyclerView.setAdapter(adapter);
    }

    @Click
    void bookFloatingActionButton() {
        ReservationActivity_.intent(this)
                .villa(villa)
                .start();
    }
}
