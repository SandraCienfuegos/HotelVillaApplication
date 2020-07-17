package be.cienfuegos.sandra.hotel_villa_application.tool;

import android.content.Context;

import com.bumptech.glide.Glide;
import com.bumptech.glide.Registry;
import com.bumptech.glide.annotation.GlideModule;
import com.bumptech.glide.integration.okhttp3.OkHttpUrlLoader;
import com.bumptech.glide.load.model.GlideUrl;
import com.bumptech.glide.module.AppGlideModule;

import org.jetbrains.annotations.NotNull;

import java.io.InputStream;
import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;

/**
 * Code issu d'internet qui initialise Glide avec un OkHttpClient non sécurisé
 */
@GlideModule
public class UnsafeOkHttpGlideModule extends AppGlideModule {
    @Override
    public void registerComponents(@NotNull Context context, @NotNull Glide glide, Registry registry) {
        OkHttpClient client = UnsafeOkHttpClient.getUnsafeOkHttpClient();
        registry.replace(GlideUrl.class, InputStream.class,
                new OkHttpUrlLoader.Factory(client));
    }
}