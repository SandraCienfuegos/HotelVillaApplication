package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.widget.Toast;

import com.google.android.material.textfield.TextInputEditText;

import org.androidannotations.annotations.Background;
import org.androidannotations.annotations.Click;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Fullscreen;
import org.androidannotations.annotations.LongClick;
import org.androidannotations.annotations.UiThread;
import org.androidannotations.annotations.ViewById;

import java.util.Objects;

import be.cienfuegos.sandra.hotel_villa_application.api.HotelVillaApiClient;
import be.cienfuegos.sandra.hotel_villa_application.api.model.AuthenticatedCustomer;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Credentials;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaHotelApiResponse;

@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_sign_in)
public class SignInActivity extends Activity {
    @ViewById(R.id.email_edit_text)
    TextInputEditText emailEditText;

    @ViewById(R.id.password_edit_text)
    TextInputEditText passwordEditText;

    @Click(value = R.id.sign_in_button)
    void signInButtonClick() {
        String email = Objects.requireNonNull(emailEditText.getText()).toString();
        String password = Objects.requireNonNull(passwordEditText.getText()).toString();
        if (email.isEmpty() || password.isEmpty()) {
            Toast.makeText(this, R.string.not_empty_value, Toast.LENGTH_SHORT).show();
        } else {
            signInProcess(new Credentials(email, password));
        }
    }

    @SuppressLint("SetTextI18n")
    @LongClick(value = R.id.sign_in_button)
    void signInButtonPopulateForm() {
        emailEditText.setText("dolores.poveda@gmail.com");
        passwordEditText.setText("dpoveda");
    }


    @Background
    protected void signInProcess(Credentials credentials) {
        signInResult(HotelVillaApiClient.getInstance().signInUser(credentials));
    }

    @UiThread
    protected void signInResult(VillaHotelApiResponse<AuthenticatedCustomer> response) {
        if (response.isSuccess()) {
            HomeActivity_.intent(SignInActivity.this).start();
            AuthenticatedCustomer authenticatedCustomer = response.getData();
            String welcomeMessage = String.format(getString(R.string.hello_message), authenticatedCustomer.getFirstName());
            Toast.makeText(this, welcomeMessage, Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(this, response.getStatus().getErrorMessage(), Toast.LENGTH_LONG).show();
        }
    }

    @Click
    void signUpButton() {
        SignUpActivity_.intent(SignInActivity.this).start();
    }
}
