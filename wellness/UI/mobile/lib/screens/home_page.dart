import 'package:flutter/material.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:mobile/screens/my_reservation_page.dart';
import 'package:mobile/screens/membership_page.dart';
import 'package:mobile/screens/profil_page.dart';
import 'package:mobile/screens/treatment_overview_page.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/custom_button.dart';
import 'package:signalr_netcore/signalr_client.dart';

class HomepageView extends StatefulWidget {
  const HomepageView({Key? key}) : super(key: key);

  @override
  _HomepageViewState createState() => _HomepageViewState();
}

class _HomepageViewState extends State<HomepageView> {
  int _numberOfNotifications = 0;

  late HubConnection _signalR;

  @override
  void initState() {
    super.initState();
    _initPlatformState();
  }

  Future<void> _initPlatformState() async {
    _signalR = HubConnectionBuilder()
        .withUrl("http://10.0.2.2:5000/notificationHub")
        .build();

    _signalR.on("ReceiveNotification", _onNewMessage);

    await _signalR.start();
  }

  void _onNewMessage(List<dynamic>? parameters) {
    // Ovdje možete obraditi parametre dobivene iz signalR poruke
    if (parameters != null && parameters.isNotEmpty) {
      print("Received notification: ${parameters.first}");

      // Ažurirajte broj notifikacija
      _updateNotifications();
    }
  }

  void _updateNotifications() {
    setState(() {
      _numberOfNotifications++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Container(
          margin: const EdgeInsets.only(bottom: 100.0),
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const CustomButton(
                  text: 'Pregled Tretmana',
                  navigateTo: TreatmentOverview(),
                ),
                CustomButton(
                  text:
                      'Moje rezervacije ${_numberOfNotifications > 0 ? '($_numberOfNotifications)' : ''}',
                  navigateTo: const MyReservationPageView(),
                ),
                const CustomButton(
                  text: 'Članarina',
                  navigateTo: MemberShipPageView(),
                ),
                const CustomButton(
                  text: 'Profil',
                  navigateTo: ProfilPageView(),
                ),
                const CustomButton(
                  text: 'Odjava',
                  navigateTo: LoginPageView(),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
