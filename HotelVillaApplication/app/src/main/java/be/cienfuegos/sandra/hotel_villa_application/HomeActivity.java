package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;

import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.androidannotations.annotations.AfterViews;
import org.androidannotations.annotations.Background;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Fullscreen;
import org.androidannotations.annotations.UiThread;
import org.androidannotations.annotations.ViewById;

import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view.VillaAdapter;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Villa;


@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_home)
public class HomeActivity extends Activity {

    @ViewById(R.id.villas_recycler_view)
    RecyclerView villasRecyclerView;

    @AfterViews
    protected void initView() {
        villasRecyclerView.setHasFixedSize(true);
        villasRecyclerView.setLayoutManager(new LinearLayoutManager(this));
        fetchVillas();
    }

    @Background
    protected void fetchVillas() {
        showVillas(HotelVillaApiClient.getInstance().getVillas());
    }

    @UiThread
    protected void showVillas(List<Villa> villas) {
        RecyclerView.Adapter adapter = new VillaAdapter(villas, R.layout.villa_card);
        villasRecyclerView.setAdapter(adapter);
    }
}
