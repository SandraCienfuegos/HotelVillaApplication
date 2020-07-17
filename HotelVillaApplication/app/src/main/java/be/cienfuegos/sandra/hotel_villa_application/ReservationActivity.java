package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.graphics.Typeface;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.google.android.material.textfield.TextInputEditText;
import com.savvi.rangedatepicker.CalendarPickerView;
import com.synnapps.carouselview.CarouselView;

import org.androidannotations.annotations.AfterViews;
import org.androidannotations.annotations.Background;
import org.androidannotations.annotations.CheckedChange;
import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Extra;
import org.androidannotations.annotations.Fullscreen;
import org.androidannotations.annotations.UiThread;
import org.androidannotations.annotations.ViewById;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.List;

import be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view.ExtraAdapter;
import be.cienfuegos.sandra.hotel_villa_application.adapter.recycler_view.ServiceAdapter;
import be.cienfuegos.sandra.hotel_villa_application.adapter.spinner.FormulaAdapter;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Formula;
import be.cienfuegos.sandra.hotel_villa_application.api.model.NewReservation;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Service;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Villa;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaHotelApiResponse;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaMedia;

@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_reservation)
public class ReservationActivity extends Activity {

    @Extra
    Villa villa;

    @ViewById(R.id.villa_name_text_view)
    TextView villaNameEditText;

    @ViewById(R.id.villa_media_carousel_view)
    CarouselView villaMediaCarouselView;

    @ViewById(R.id.price_choice_radio_group)
    RadioGroup priceChoiceRadioGroup;

    @ViewById(R.id.price_online_radio_button)
    RadioButton priceOnlineRadioButton;

    @ViewById(R.id.price_on_site_radio_button)
    RadioButton priceOnSiteRadioButton;

    @ViewById(R.id.formulas_spinner)
    Spinner formulasSpinner;

    @ViewById(R.id.number_of_adults_edit_text)
    TextInputEditText numberOfAdultsEditText;

    @ViewById(R.id.number_of_children_edit_text)
    TextInputEditText numberOfChildrenEditText;

    @ViewById(R.id.number_of_babies_edit_text)
    TextInputEditText numberOfBabiesEditText;

    @ViewById(R.id.reservation_dates_calendar_picker_view)
    CalendarPickerView reservationDatesCalendarPickerView;

    @ViewById(R.id.services_recycler_view)
    RecyclerView servicesRecyclerView;

    @ViewById(R.id.extras_recycler_view)
    RecyclerView extrasRecyclerView;

    private ServiceAdapter serviceAdapter;

    private ExtraAdapter extraAdapter;

    @AfterViews
    protected void initView() {
        villaNameEditText.setText(villa.getVillaName());

        int width = villaMediaCarouselView.getLayoutParams().width;
        int height = this.getResources().getDisplayMetrics().heightPixels / 3;

        villaMediaCarouselView.setLayoutParams(new LinearLayout.LayoutParams(width, height));

        final List<VillaMedia> villaMedias = villa.getMedias();

        villaMediaCarouselView.setImageListener((position, imageView) -> Glide
                .with(ReservationActivity.this)
                .load(HotelVillaApiClient.getInstance().getVillaMediaUrl(villaMedias.get(position)))
                .into(imageView));
        villaMediaCarouselView.setPageCount(villa.getMedias().size());

        priceOnlineRadioButton.setText(String.format("%.2f€", villa.getPriceOnline()));
        priceOnlineRadioButton.setTypeface(null, Typeface.BOLD);
        priceOnSiteRadioButton.setText(String.format("%.2f€", villa.getPriceOnSite()));

        ArrayAdapter<Formula> formulaAdapter = new FormulaAdapter(this, R.layout.formula_tile, villa.getFormulas());
        formulasSpinner.setAdapter(formulaAdapter);

        servicesRecyclerView.setHasFixedSize(false);
        servicesRecyclerView.setLayoutManager(new LinearLayoutManager(this));

        extrasRecyclerView.setHasFixedSize(false);
        extrasRecyclerView.setLayoutManager(new LinearLayoutManager(this));

        Date minDate = new Date();
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(minDate);
        calendar.add(Calendar.YEAR, 1);

        reservationDatesCalendarPickerView
                .init(minDate, calendar.getTime())
                .inMode(CalendarPickerView.SelectionMode.RANGE);

        fetchServicesExtrasAndBookedDates();
    }

    @Background
    protected void fetchServicesExtrasAndBookedDates() {
        showServicesExtrasAndBookedDates(
                HotelVillaApiClient.getInstance().getServices(),
                HotelVillaApiClient.getInstance().getExtras(),
                HotelVillaApiClient.getInstance().getVillaBookedDates(villa.getVillaId())
        );
    }

    @UiThread
    protected void showServicesExtrasAndBookedDates(List<Service> services, List<be.cienfuegos.sandra.hotel_villa_application.api.model.Extra> extras, List<Date> bookedDates) {
        serviceAdapter = new ServiceAdapter(services, R.layout.service_tile);
        servicesRecyclerView.setAdapter(serviceAdapter);

        extraAdapter = new ExtraAdapter(extras, R.layout.extra_tile);
        extrasRecyclerView.setAdapter(extraAdapter);

        reservationDatesCalendarPickerView.deactivateDates(new ArrayList<>(Collections.singletonList(bookedDates.size())));
        reservationDatesCalendarPickerView.highlightDates(bookedDates);
    }

    @CheckedChange({R.id.price_online_radio_button, R.id.price_on_site_radio_button})
    public void onRadioButtonCheckChanged(CompoundButton button, boolean checked) {
        if (priceOnlineRadioButton.isChecked()) {
            priceOnlineRadioButton.setTypeface(null, Typeface.BOLD);
            priceOnSiteRadioButton.setTypeface(null, Typeface.NORMAL);
        } else {
            priceOnlineRadioButton.setTypeface(null, Typeface.NORMAL);
            priceOnSiteRadioButton.setTypeface(null, Typeface.BOLD);
        }
    }

    @Click
    void bookButton() {
        NewReservation newReservation = new NewReservation(
                villa.getVillaId(),
                ((Formula) formulasSpinner.getSelectedItem()).getFormulaId(),
                Integer.parseInt(numberOfAdultsEditText.getText().toString()),
                Integer.parseInt(numberOfChildrenEditText.getText().toString()),
                Integer.parseInt(numberOfBabiesEditText.getText().toString()),
                priceOnlineRadioButton.isChecked() ? 1 : 2,
                reservationDatesCalendarPickerView.getSelectedDates().get(0),
                reservationDatesCalendarPickerView.getSelectedDates().get(reservationDatesCalendarPickerView.getSelectedDates().size() - 1),
                extraAdapter.getSelectedReservationExtras(),
                serviceAdapter.getSelectedReservationServices()
        );
        sendReservation(newReservation);
    }

    @Background
    protected void sendReservation(NewReservation newReservation) {
        showReservationResult(HotelVillaApiClient.getInstance().book(newReservation));
    }

    @UiThread
    protected void showReservationResult(VillaHotelApiResponse<Boolean> villaHotelApiResponse) {
        if (villaHotelApiResponse.isSuccess()) {
            Toast.makeText(this, "Success", Toast.LENGTH_LONG).show();
            finish();
        } else {
            Toast.makeText(this, villaHotelApiResponse.getStatus().getErrorMessage(), Toast.LENGTH_LONG).show();
        }
    }
}