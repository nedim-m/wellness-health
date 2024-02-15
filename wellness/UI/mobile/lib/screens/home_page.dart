import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
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
  bool status = false;
  final UserProvider _userProvider = UserProvider();

  late HubConnection _signalR;

  @override
  void initState() {
    super.initState();
    _initPlatformState();
    getAccess();
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
      print("print svih parametara: $parameters");
      print("Received notification: ${parameters.first}");
      String notification = parameters.first;
      String idString = notification.replaceAll(RegExp(r'[^0-9]'), '');
      print('Received notification with id: $idString');
      var userId = UserManager.getUserId()!;

      if (notification.contains("Mobile")) {
        if (userId == idString) {
          _updateNotifications();
        }
      }
    }
  }

  void _updateNotifications() {
    if (mounted) {
      setState(() {
        _numberOfNotifications++;
      });
    }
  }

  void _resetNotifications() {
    setState(() {
      _numberOfNotifications = 0;
    });
  }

  Future<void> getAccess() async {
    var user = await _userProvider.getById();
    setState(() {
      status = user.status!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        _resetNotifications();
        return true;
      },
      child: Scaffold(
        appBar: const AppBarWidget(),
        body: SingleChildScrollView(
          child: Container(
            margin: const EdgeInsets.only(bottom: 100.0),
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  CustomButton(
                    text: 'Pregled Tretmana',
                    navigateTo: status
                        ? const TreatmentOverview()
                        : const MemberShipPageView(),
                  ),
                  CustomButton(
                    text: 'Moje rezervacije',
                    navigateTo: const MyReservationPageView(),
                    notificationCount: _numberOfNotifications,
                    onPressedCustom: () {
                      _resetNotifications();
                    },
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
      ),
    );
  }
}
