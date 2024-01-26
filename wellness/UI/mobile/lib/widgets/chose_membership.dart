import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/membership_type.dart';
import 'package:mobile/providers/membership_type_provider.dart';
import 'package:mobile/screens/payment_page.dart';
import 'package:mobile/utils/current_date.dart';

import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class ChoseMembershipPageView extends StatefulWidget {
  const ChoseMembershipPageView({Key? key}) : super(key: key);

  @override
  State<ChoseMembershipPageView> createState() =>
      _ChoseMembershipPageViewState();
}

class _ChoseMembershipPageViewState extends State<ChoseMembershipPageView> {
  final MembershipTypeProvider _membershipTypeProvider =
      MembershipTypeProvider();

  late List<MembershipType> membershipTypes = [];
  MembershipType? selectedMembershipType;

  var currentDate = CurrentDate();

  @override
  void initState() {
    super.initState();

    fetchData();
  }

  Future<void> fetchData() async {
    membershipTypes = await _membershipTypeProvider.get();
    if (membershipTypes.isNotEmpty) {
      selectedMembershipType = membershipTypes[0];
    }
    if (mounted) {
      setState(() {});
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: buildContent(),
      ),
    );
  }

  Widget buildContent() {
    return ListView(
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
        const Text(
          'Odaberite tip članarine:',
          style: TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
        ),
        const SizedBox(height: 8),
        DropdownButton<MembershipType>(
          value: selectedMembershipType,
          onChanged: (MembershipType? newValue) {
            setState(() {
              selectedMembershipType = newValue;
            });
          },
          items: membershipTypes.map((MembershipType type) {
            return DropdownMenuItem<MembershipType>(
              value: type,
              child: Text(type.name),
            );
          }).toList(),
        ),
        const Gap(15),
        DoubleTextWidget(
          bigText: "Trajanje: ",
          smallText: selectedMembershipType != null
              ? "${selectedMembershipType!.duration.toString()} mjeseci"
              : "N/A",
        ),
        const Gap(15),
        DoubleTextWidget(
          bigText: "Cijena: ",
          smallText: selectedMembershipType != null
              ? "${selectedMembershipType!.price.toString()} BAM"
              : "N/A",
        ),
        const Gap(15),
        DoubleTextWidget(
          bigText: "Datum aktivacije: ",
          smallText: currentDate.currentDate,
        ),
        const Gap(15),
        const Gap(50),
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => PaymentPageView(
                    memberShipTypeName: selectedMembershipType?.name ?? "N/A",
                    price: selectedMembershipType!.price.toString(),
                  ),
                ),
              );
            },
            child: const Text("Uplati članarinu"),
          ),
        ),
      ],
    );
  }
}
