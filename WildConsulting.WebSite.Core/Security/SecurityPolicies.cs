using Microsoft.Extensions.Primitives;

namespace WildConsulting.WebSite.Core.Security;

public static class SecurityPolicies
{
    public static StringValues FeaturesList = new(
        "accelerometer 'none';" +
        "autoplay 'none';" +
        "camera 'none';" +
        "document-domain 'none';" +
        "encrypted-media 'none';" +
        "fullscreen 'self';" +
        "geolocation 'none';" +
        "gyroscope 'none';" +
        "magnetometer 'none';" +
        "microphone 'none';" +
        "midi 'none';" +
        "payment 'none';" +
        "picture-in-picture 'none';" +
        "publickey-credentials-get 'none';" +
        "sync-xhr 'none';" +
        "usb 'none';" +
        "xr-spatial-tracking 'none';");

    public static StringValues PermissionsList = new(
            "accelerometer=();" +
            "autoplay=();" +
            "camera=();" +
            "document-domain=();" +
            "encrypted-media=();" +
            "fullscreen=(self);" +
            "geolocation=();" +
            "gyroscope=();" +
            "magnetometer=();" +
            "microphone=();" +
            "midi=();" +
            "payment=();" +
            "picture-in-picture=();" +
            "publickey-credentials-get=();" +
            "speaker=(self);" +
            "sync-xhr=();" +
            "usb=();" +
            "xr-spatial-tracking=();");
}