package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.widget.ArrayAdapter;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.material.textfield.TextInputEditText;

import org.androidannotations.annotations.AfterViews;
import org.androidannotations.annotations.Background;
import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Fullscreen;
import org.androidannotations.annotations.LongClick;
import org.androidannotations.annotations.UiThread;
import org.androidannotations.annotations.ViewById;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Objects;

import be.cienfuegos.sandra.hotel_villa_application.adapter.spinner.CountryAdapter;
import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Address;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Country;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Sex;
import be.cienfuegos.sandra.hotel_villa_application.api.model.SignUpCustomer;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaHotelApiResponse;
import lombok.SneakyThrows;

@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_sign_up)
public class SignUpActivity extends Activity {
    @ViewById(R.id.sex_radio_group)
    RadioGroup sexRadioGroup;

    @ViewById(R.id.male_radio_button)
    RadioButton maleRadioButton;

    @ViewById(R.id.female_radio_button)
    RadioButton femaleRadioButton;

    @ViewById(R.id.last_name_edit_text)
    TextInputEditText lastNameEditText;

    @ViewById(R.id.first_name_edit_text)
    TextInputEditText firstNameEditText;

    @ViewById(R.id.phone_number_edit_text)
    TextInputEditText phoneNumberEditText;

    @ViewById(R.id.email_edit_text)
    TextInputEditText emailEditText;

    @ViewById(R.id.birthday_date_edit_text)
    TextInputEditText birthdayDateEditText;

    @ViewById(R.id.password_edit_text)
    TextInputEditText passwordEditText;

    @ViewById(R.id.address_line_one_edit_text)
    TextInputEditText addressLineOneEditText;

    @ViewById(R.id.address_line_two_edit_text)
    TextInputEditText addressLineTwoEditText;

    @ViewById(R.id.countries_spinner)
    Spinner countriesSpinner;

    @ViewById(R.id.city_edit_text)
    TextInputEditText cityEditText;

    @ViewById(R.id.postal_code_edit_text)
    TextInputEditText postalCodeEditText;

    @AfterViews
    protected void initView() {
        fetchCountries();
    }

    @Background
    protected void fetchCountries() {
        displayCountries(HotelVillaApiClient.getInstance().getCountries());
    }

    @UiThread
    protected void displayCountries(List<Country> countries) {
        ArrayAdapter<Country> countryAdapter = new CountryAdapter(this, android.R.layout.simple_spinner_item, countries);
        countriesSpinner.setAdapter(countryAdapter);
    }

    @SuppressLint("SimpleDateFormat")
    @SneakyThrows
    @Click(value = R.id.sign_up_button)
    void signUpButton() {
        Sex sex = sexRadioGroup.getCheckedRadioButtonId() == maleRadioButton.getId() ? Sex.MALE : Sex.FEMALE;
        String lastName = Objects.requireNonNull(lastNameEditText.getText()).toString();
        String firstName = Objects.requireNonNull(firstNameEditText.getText()).toString();
        String phoneNumber = Objects.requireNonNull(phoneNumberEditText.getText()).toString();
        String email = Objects.requireNonNull(emailEditText.getText()).toString();
        String birthdayDate = Objects.requireNonNull(birthdayDateEditText.getText()).toString();
        String password = Objects.requireNonNull(passwordEditText.getText()).toString();
        Country country = (Country) countriesSpinner.getSelectedItem();
        String addressLineOne = Objects.requireNonNull(addressLineOneEditText.getText()).toString();
        String addressLineTwo = Objects.requireNonNull(addressLineTwoEditText.getText()).toString();
        String city = Objects.requireNonNull(cityEditText.getText()).toString();
        String postalCode = Objects.requireNonNull(postalCodeEditText.getText()).toString();

        SignUpCustomer signUpCustomer = new SignUpCustomer(
                new Address(
                        country,
                        country.getCountryId(),
                        addressLineOne,
                        addressLineTwo,
                        postalCode,
                        city),
                firstName,
                lastName,
                phoneNumber,
                email,
                password,
                new SimpleDateFormat("yyyy/MM/dd").parse(birthdayDate),
                sex.id
        );
        signUpProcess(signUpCustomer);
    }

    @SuppressLint("SetTextI18n")
    @LongClick(value = R.id.sign_up_button)
    void signUpButtonPopulateForm() {
        femaleRadioButton.setChecked(true);
        lastNameEditText.setText("Cienfuegos");
        firstNameEditText.setText("Sandra");
        phoneNumberEditText.setText("+32470568875");
        emailEditText.setText("sandra.cienfuegos@gmail.com");
        birthdayDateEditText.setText("01/01/2000");
        passwordEditText.setText("scienfuegos");
        countriesSpinner.setSelection(0);
        addressLineOneEditText.setText("Avenue Minerve, 27");
        addressLineTwoEditText.setText("");
        cityEditText.setText("Bruxelles");
        postalCodeEditText.setText("1190");
    }


    @Background
    protected void signUpProcess(SignUpCustomer signUpCustomer) {
        signUpResult(HotelVillaApiClient.getInstance().signUpUser(signUpCustomer));
    }

    @UiThread
    protected void signUpResult(VillaHotelApiResponse<Boolean> response) {
        if (response.isSuccess()) {
            String welcomeMessage = String.format(getString(R.string.welcome_message), firstNameEditText.getText());
            Toast.makeText(this, welcomeMessage, Toast.LENGTH_SHORT).show();
            finish();
        } else {
            Toast.makeText(this, response.getStatus().getErrorMessage(), Toast.LENGTH_LONG).show();
        }
    }
}
