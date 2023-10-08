import 'package:desktop/screens/category_page.dart';
import 'package:desktop/screens/record_page.dart';
import 'package:desktop/screens/treatment_page.dart';
import 'package:desktop/screens/treatment_type_page.dart';
import 'package:desktop/screens/user_page.dart';
import 'package:desktop/screens/worker_page.dart';
import 'package:fluent_ui/fluent_ui.dart';

import 'membership_type.dart';

class HomepageView extends StatefulWidget {
  const HomepageView({super.key});

  @override
  State<HomepageView> createState() => _HomepageViewState();
}

class _HomepageViewState extends State<HomepageView> {
  int topIndex = 0;

  PaneDisplayMode displayMode = PaneDisplayMode.top;

  List<NavigationPaneItem> items = [
    PaneItem(
      icon: const Icon(FluentIcons.people),
      title: const Text('Korisnici'),
      body: const UserPageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.teamwork),
      title: const Text('Zaposlenici'),
      body: const WorkerPageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.temporary_user),
      title: const Text('Trenutno prisutni'),
      body: const RecordPageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.service_activity),
      title: const Text('Vrste usluge'),
      body: const TreatmentTypePageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.category_classification),
      title: const Text('Kategorije'),
      body: const CategoryPageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.medical_care),
      title: const Text('Tretmani'),
      body: const TreatmentPageView(),
    ),
    PaneItem(
      icon: const Icon(FluentIcons.payment_card),
      title: const Text('Članarina'),
      body: const MembershipTypePageView(),
    ),
    PaneItemExpander(
      title: const Text('Izvjestaj'),
      icon: const Icon(FluentIcons.report_document),
      body: const Text("This is text"),
      items: [
        PaneItem(
          icon: const Icon(FluentIcons.mail),
          title: const Text('Kreiraj'),
          body: const Text("Kreiraj izvjestaj"),
        ),
        PaneItem(
          icon: const Icon(FluentIcons.calendar),
          title: const Text('Prikaži'),
          body: const Text('Prikaži'),
        ),
      ],
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return NavigationView(
      appBar: const NavigationAppBar(
          title: Center(
              child: Text(
        "Wellness center Health",
        style: TextStyle(fontSize: 30),
      ))),
      pane: NavigationPane(
          selected: topIndex,
          onChanged: (index) => setState(() => topIndex = index),
          displayMode: displayMode,
          items: items,
          footerItems: [
            PaneItem(
              icon: const Icon(FluentIcons.leave_user),
              title: const Text('Odjava'),
              body: const Text("Home6"),
              onTap: () {
                Navigator.pop(context);
              },
            ),
          ]),
    );
  }
}
