using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Helpers;

public static class NetworkProviderResolver
{
    private static readonly Dictionary<string, NetworkProvider> NumberPrefixes = new()
    {
        //MTN
        { "0803", NetworkProvider.MTN },
        { "0806", NetworkProvider.MTN },
        { "0703", NetworkProvider.MTN },
        { "0704", NetworkProvider.MTN },
        { "0706", NetworkProvider.MTN },
        { "0810", NetworkProvider.MTN },
        { "0813", NetworkProvider.MTN },
        { "0814", NetworkProvider.MTN },
        { "0816", NetworkProvider.MTN },
        { "0903", NetworkProvider.MTN },
        { "0906", NetworkProvider.MTN },
        { "0913", NetworkProvider.MTN },
        { "0916", NetworkProvider.MTN },

        //Airtel
        { "0802", NetworkProvider.Airtel },
        { "0808", NetworkProvider.Airtel },
        { "0812", NetworkProvider.Airtel },
        { "0701", NetworkProvider.Airtel },
        { "0708", NetworkProvider.Airtel },
        { "0901", NetworkProvider.Airtel },
        { "0902", NetworkProvider.Airtel },
        { "0904", NetworkProvider.Airtel },
        { "0907", NetworkProvider.Airtel },
        { "0912", NetworkProvider.Airtel },

        // Glo
        { "0805", NetworkProvider.Glo },
        { "0807", NetworkProvider.Glo },
        { "0705", NetworkProvider.Glo },
        { "0811", NetworkProvider.Glo },
        { "0815", NetworkProvider.Glo },
        { "0905", NetworkProvider.Glo },
        { "0915", NetworkProvider.Glo },

        // Etisalat (9mobile)
        { "0809", NetworkProvider.Etisalat },
        { "0817", NetworkProvider.Etisalat },
        { "0818", NetworkProvider.Etisalat },
        { "0908", NetworkProvider.Etisalat },
        { "0909", NetworkProvider.Etisalat },
    };

    public static NetworkProvider? DetectNetworkProvider(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 4)
            return null;

        var prefix = phoneNumber[..4];

        return NumberPrefixes.TryGetValue(prefix, out var provider)
            ? provider
            : null;
    }
}