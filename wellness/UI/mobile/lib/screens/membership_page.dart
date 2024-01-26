import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/membership.dart';
import 'package:mobile/providers/membership_provider.dart';
import 'package:mobile/screens/payment_page.dart';
import 'package:mobile/utils/user_store.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class MemberShipPageView extends StatefulWidget {
  const MemberShipPageView({Key? key}) : super(key: key);

  @override
  _MemberShipPageViewState createState() => _MemberShipPageViewState();
}

class _MemberShipPageViewState extends State<MemberShipPageView> {
  final MembershipProvider _membershipProvider = MembershipProvider();
  late int _userId;
  Membership? data;
  List<Membership> membership = [];

  @override
  void initState() {
    super.initState();
    _userId = int.parse(UserManager.getUserId()!);
    fetchData();
  }

  Future<void> fetchData() async {
    var fetchedData = await _membershipProvider.get(filter: {
      'userId': _userId,
    });

    if (fetchedData.isNotEmpty) {
      setState(() {
        data = fetchedData.first;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 20),
              const Center(
                child: Text(
                  'Članarina',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              DoubleTextWidget(
                bigText: "Tip članarine: ",
                smallText: data?.memberShipTypeName ?? "N/A",
              ),
              const Gap(15),
              DoubleTextWidget(
                bigText: "Status članarine: ",
                smallText: data?.status == true ? "Aktivan" : "Neaktivan",
              ),
              const Gap(15),
              DoubleTextWidget(
                bigText: "Datum aktivacije: ",
                smallText: data?.startDate ?? "N/A",
              ),
              const Gap(15),
              DoubleTextWidget(
                bigText: "Datum isteka: ",
                smallText: data?.expirationDate ?? "N/A",
              ),
              const Gap(50),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => PaymentPageView(
                            memberShipTypeName: data!.memberShipTypeName,
                            currentExpDate: data!.expirationDate),
                      ),
                    );
                  },
                  child: const Text("Uplati/produži članarinu"),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
