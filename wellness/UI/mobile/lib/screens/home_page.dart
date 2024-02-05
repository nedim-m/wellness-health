import 'package:flutter/material.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:mobile/screens/my_reservation_page.dart';
import 'package:mobile/screens/membership_page.dart';
import 'package:mobile/screens/profil_page.dart';
import 'package:mobile/screens/treatment_overview_page.dart';
import 'package:mobile/utils/user_store.dart';
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
    if (parameters != null && parameters.isNotEmpty) {
      print("Received notification: ${parameters.first}");
      String notification = parameters.first;
      String idString = notification.replaceAll(RegExp(r'[^0-9]'), '');
      print('Received notification with id: $idString');
      var userId = UserManager.getUserId()!;
      print("Logged user id is: $userId");

      if (notification.contains("Mobile")) {
        if (userId == idString) {
          _updateNotifications();
        }
      }
    }
  }

  void _updateNotifications() {
    setState(() {
      _numberOfNotifications++;
    });
  }

  void _resetNotifications() {
    setState(() {
      _numberOfNotifications = 0;
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
                  text: 'Moje rezervacije',
                  navigateTo: const MyReservationPageView(),
                  notificationCount: _numberOfNotifications,
                  onPressed: _resetNotifications,
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
