import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/membership.dart';
import 'package:mobile/providers/membership_provider.dart';

import 'package:mobile/utils/user_store.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/chose_membership.dart';
import 'package:mobile/widgets/double_text.dart';

class MemberShipPageView extends StatefulWidget {
  const MemberShipPageView({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _MemberShipPageViewState createState() => _MemberShipPageViewState();
}

class _MemberShipPageViewState extends State<MemberShipPageView> {
  final MembershipProvider _membershipProvider = MembershipProvider();
  late int _userId;
  Membership? data;

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
              if (data != null) ...[
                DoubleTextWidget(
                  bigText: "Trenutno aktivni tip članarine: ",
                  smallText: data!.memberShipTypeName,
                ),
                const Gap(15),
                DoubleTextWidget(
                  bigText: "Status članarine: ",
                  smallText: data!.status == true ? "Aktivan" : "Neaktivan",
                ),
                const Gap(15),
                DoubleTextWidget(
                  bigText: "Datum aktivacije: ",
                  smallText: data!.startDate,
                ),
                const Gap(15),
                DoubleTextWidget(
                  bigText: "Datum isteka: ",
                  smallText: data!.expirationDate,
                ),
                const Gap(20),
                if (data!.status == false)
                  const Center(
                    child: Text(
                      'Molim vas da produžite članarinu kako biste mogli nastaviti sa korištenjem usluga. Hvala Vam na razumijevanju.',
                      style: TextStyle(fontSize: 18, color: Colors.red),
                    ),
                  ),
              ] else ...[
                const Center(
                  child: Text(
                    'Da bi ste mogli pregledati tretmane i rezervisati tretman morate postati član i uplatiti članarinu. Hvala Vam na razumijevanju.',
                    style: TextStyle(fontSize: 18, color: Colors.red),
                  ),
                )
              ],
              const Gap(50),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => const ChoseMembershipPageView(),
                      ),
                    );
                  },
                  child: Text(
                    data != null ? "Produži članarinu" : "Izaberi članarinu",
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
